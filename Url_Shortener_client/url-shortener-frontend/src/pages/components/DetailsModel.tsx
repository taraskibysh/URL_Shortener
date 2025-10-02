import {UrlType} from "../../types";

interface DetailsModelProps{
    url : UrlType,
    onClose: () => void,
}

export const DetailsModel = ({ url, onClose }: DetailsModelProps) => {
    return ( <div
            style={{
                position: "fixed",
                top: 0,
                left: 0,
                width: "100vw",
                height: "100vh",
                backgroundColor: "rgba(0,0,0,0.5)",
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                zIndex: 1000,
            }}
        >
            <div
                style={{
                    backgroundColor: "#fff",
                    padding: "20px",
                    borderRadius: "8px",
                    width: "400px",
                }}
            >
                <h2>Деталі URL</h2>
                <p><strong>ID:</strong> {url.id}</p>
                <p><strong>Оригінальний URL:</strong> <a href={url.shortUrl} target="_blank" rel="noopener noreferrer">{url.originalUrl}</a></p>
                <p><strong>Скорочений URL:</strong> <a href={url.shortUrl} target="_blank" rel="noopener noreferrer">{url.shortUrl}</a></p>
                <p><strong>Власник:</strong> {url.ownerName}</p>
                <p><strong>Створено:</strong> {new Date(url.createdAt).toLocaleString()}</p>

                <div style={{ display: "flex", justifyContent: "flex-end", marginTop: "15px" }}>
                    <button
                        onClick={() => onClose()}
                        style={{
                            padding: "8px 16px",
                            backgroundColor: "#007bff",
                            color: "#fff",
                            border: "none",
                            borderRadius: "4px",
                            cursor: "pointer",
                        }}
                    >
                        Закрити
                    </button>
                </div>
            </div>
        </div>
    );
}