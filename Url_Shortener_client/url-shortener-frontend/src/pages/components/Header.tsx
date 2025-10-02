import {User} from "../../types";

interface HeaderProps {
    user: User | null;
    token: string | null ;
    handleLoginLogout: () => void;
    handleCreateClick: () => void;
}

export const HomeHeader = ({user, token, handleCreateClick, handleLoginLogout}:HeaderProps) => {

    return ( <header
        style={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            padding: "10px 20px",
            backgroundColor: "#f0f0f0",
            marginBottom: "20px",
        }}
    >
        <div>
            <h1>Список URL</h1>
            {user && <p>Привіт, {user.name}</p>}
        </div>
        <div style={{ display: "flex", gap: "10px", alignItems: "center" }}>
            <button
                onClick={handleCreateClick}
                style={{
                    padding: "8px 16px",
                    backgroundColor: token ? "#007bff" : "#aaa",
                    color: "#fff",
                    border: "none",
                    borderRadius: "4px",
                    cursor: token ? "pointer" : "not-allowed",
                }}
                disabled={!token} // блокуємо якщо не залогінений
            >
                Створити URL
            </button>
            <button
                onClick={handleLoginLogout}
                style={{
                    padding: "8px 16px",
                    backgroundColor: "#28a745",
                    color: "#fff",
                    border: "none",
                    borderRadius: "4px",
                    cursor: "pointer",
                }}
            >
                {user ? "Вийти" : "Логін"}
            </button>
        </div>
    </header>)
}