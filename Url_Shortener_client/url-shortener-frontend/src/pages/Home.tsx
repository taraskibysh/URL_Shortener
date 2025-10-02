import { useState, useContext, useEffect } from "react";
import { UrlList } from "./components/UrlList";
import { CreateUrl, DeleteUrl, GetAll } from "../api/Urls";
import { AuthContext } from "../contexts/AuthContext";
import { UrlType } from "../types";
import { useNavigate } from "react-router-dom";
import {HomeHeader} from "./components/Header";
import {CreateModel} from "./components/CreateModel";

export const HomePage = () => {
    const [showCreate, setShowCreate] = useState(false);
    const [urlInput, setUrlInput] = useState("");
    const [urls, setUrls] = useState<UrlType[]>([]);
    const auth = useContext(AuthContext);
    const navigate = useNavigate();

    if (!auth) throw new Error("AuthContext not found");

    const { user, token, logout } = auth;

    const handleCreateClick = () => {
        setShowCreate(true);
    };

    const fetchData = async () => {
        try {
            console.log(user);
            const data = await GetAll();
            console.log("Fetched urls:", data);
            setUrls(data);
        } catch (err) {
            console.error("Помилка завантаження:", err);
        }
    };

    useEffect(() => {
        console.log(user);
        fetchData();
    }, [token]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (!token) {
            alert("Необхідно увійти в систему");
            return;
        }

        if (urls.some((u) => u.originalUrl === urlInput)) {
            alert("Цей URL вже існує у списку!");
            return;
        }

        try {
            const newUrl = await CreateUrl(urlInput);
            setUrls((prev) => [newUrl, ...prev]);
            setUrlInput("");
            setShowCreate(false);
        } catch (err: any) {
            alert(err.message || "Помилка створення URL");
        }
    };

    const handleDelete = async (id: number) => {
        if (!token) {
            alert("Необхідно увійти в систему");
            return;
        }

        try {
            await DeleteUrl(id);
            setUrls((prev) => prev.filter((url) => url.id !== id));
        } catch (err: any) {
            alert(err.message || "Помилка видалення URL");
        }
    };

    const handleLoginLogout = () => {
        if (user) {
            console.log(user);
            logout();
        } else {
            navigate("/login");
        }
    };

    return (
        <div>
            <HomeHeader user={user} token={token} handleLoginLogout={handleLoginLogout} handleCreateClick={handleCreateClick}/>
            <UrlList urls={urls} fetchData={fetchData} onDelete={handleDelete} user = {user} />

            {showCreate && token && (
                <CreateModel handleSubmit={handleSubmit} urlInput={urlInput} setUrlInput={setUrlInput} setShowCreate={setShowCreate} ></CreateModel>
            )}
        </div>
    );
};
