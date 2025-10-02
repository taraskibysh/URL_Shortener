import axios from "axios";
import { AuthResponse } from "../types";

const API_URL = "http://localhost:5099/api";

export const loginUser = async (email: string, password: string): Promise<AuthResponse> => {
    try {
        const response = await axios.post<AuthResponse>(`${API_URL}/login`, { email, password });
        return response.data;
    } catch (error: any) {
        throw new Error(error.response?.data?.message || "Помилка логіну");
    }
};


export const registerUser = async (username: string, email: string, password: string): Promise<AuthResponse> => {
    try {
        const response = await axios.post<AuthResponse>(`${API_URL}/register`, {username, email, password });
        return response.data;
    } catch (error: any) {
        throw new Error(error.response?.data?.message || "Помилка логіну");
    }
};
