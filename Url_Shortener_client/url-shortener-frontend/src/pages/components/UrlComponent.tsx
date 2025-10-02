import { UrlType, User } from "../../types";
import { useEffect, useState } from "react";
import {DetailsModel} from "./DetailsModel";

interface UrlComponentProps {
    url: UrlType;
    onDelete?: () => void;
    user: User | null;
}

export const UrlComponent = ({ url, onDelete, user }: UrlComponentProps) => {
    const [showInfo, setShowInfo] = useState(false);

    useEffect(() => {
        console.log(url);
        console.log(user);
    }, [url, user]);

    return (
        <div
            style={{
                border: "1px solid #ddd",
                padding: "10px",
                marginBottom: "10px",
                display: "flex",
                justifyContent: "space-between",
                alignItems: "center",
            }}
        >
            <div>
                <p>{url.originalUrl}</p>
                <p>
                    <a href={url.shortUrl} target="_blank" rel="noopener noreferrer">
                        {url.shortUrl}
                    </a>
                </p>
            </div>

            <div style={{ display: "flex", gap: "10px", marginRight: "30px" }}>
                {(user?.id === url.userId || user?.role == "Admin") && (
                    <button
                        onClick={onDelete}
                        style={{
                            padding: "8px 16px",
                            backgroundColor: "red",
                            color: "#fff",
                            border: "none",
                            borderRadius: "4px",
                            cursor: "pointer",
                            margin: "10px",
                        }}
                    >
                        Видалити
                    </button>
                )}

                {user && (
                    <button
                        onClick={() => setShowInfo(true)}
                        style={{
                            padding: "8px 16px",
                            backgroundColor: "#007bff",
                            color: "#fff",
                            border: "none",
                            borderRadius: "4px",
                            cursor: "pointer",
                            margin: "10px",
                        }}
                    >
                        Деталі
                    </button>
                )}
            </div>

            {showInfo && ( <DetailsModel url={url} onClose={() => setShowInfo(false)}/>)}
        </div>
    )
};
