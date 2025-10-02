import {createContext, useState, useEffect, ReactNode} from "react";
import { User } from "../types";
import {jwtDecode} from "jwt-decode";

interface AuthContextType {
    user: User | null;
    token: string | null;
    login: (token: string, user: User) => void;
    logout: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

interface AuthProviderProps {
    children: ReactNode;
}

export const AuthProvider = ({ children }: AuthProviderProps) => {
    const [user, setUser] = useState<User | null>(null);
    const [token, setToken] = useState<string | null>(localStorage.getItem("token"));



    interface TokenPayload {
        nameid: string;
        unique_name: string;
        email: string;
        exp: number;
        role: string;
    }

    useEffect(() => {
        if (token) {
            try {
                const decoded: TokenPayload = (jwtDecode as any)(token);
                console.log(decoded);
                const now = Date.now() / 1000;
                if (decoded.exp < now) {
                    console.log("Токен прострочений");
                    setUser(null);
                    setToken(null);
                    localStorage.removeItem("token");
                    return;
                }

                setUser({
                    id: decoded.nameid,
                    name: decoded.unique_name,
                    email: decoded.email,
                    role: decoded.role
                });
                console.log(user);

            } catch (err) {
                console.error("Помилка декодування токена:", err);
                setUser(null);
                setToken(null);
                localStorage.removeItem("token");
            }
        }
    }, [token]);


    const login = (newToken: string, userData: User) => {
        setToken(newToken);
        setUser(userData);
        localStorage.setItem("token", newToken);
    };

    const logout = () => {
        setToken(null);
        setUser(null);
        localStorage.removeItem("token");
    };

    return (
        <AuthContext.Provider value={{ user, token, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};
