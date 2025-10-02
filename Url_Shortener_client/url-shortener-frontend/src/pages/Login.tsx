import { useState, useContext, FormEvent } from "react";
import { AuthContext } from "../contexts/AuthContext";
import { loginUser, registerUser } from "../api/Auth";
import './login.css';

const Login = () => {
    const auth = useContext(AuthContext);
    if (!auth) throw new Error("AuthContext not found");

    const { login } = auth;

    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [username, setUsername] = useState<string>("");
    const [error, setError] = useState<string>("");
    const [mode, setMode] = useState<"login" | "register">("login");

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        try {
            let data;
            switch (mode) {
                case "register":
                    data = await registerUser(username, email, password);
                    break;
                case "login":
                    data = await loginUser(email, password);
                    break;
                default:
                    throw new Error("Invalid mode");
            }

            login(data.token, data.user);
        } catch (err: any) {
            setError(err.message);
        }
    };

    return (
        <div className="login-container">
            <div className="mode-switch-buttons">
                <button
                    className={mode === 'login' ? 'active' : ''}
                    onClick={() => setMode('login')}
                >
                    Вхід
                </button>
                <button
                    className={mode === 'register' ? 'active' : ''}
                    onClick={() => setMode('register')}
                >
                    Реєстрація
                </button>
            </div>

            <form onSubmit={handleSubmit} className="login-form">
                {mode === "register" && (
                    <input
                        type="text"
                        placeholder="Username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                )}
                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <button type="submit">
                    {mode === "register" ? "Зарейструватись" : "Логін"}
                </button>
                {error && <p className="error-message">{error}</p>}
            </form>
        </div>
    );
};


export default Login;
