export interface User {
    id: string;
    name: string;
    email: string;
    role: string;
}

export interface AuthResponse {
    token: string;
    user: User;
}

export interface UrlType {
    id: number;
    originalUrl: string;
    shortUrl: string;
    userId: string;
    createdAt: Date;
    ownerName: string;
}
