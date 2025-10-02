interface CreateModelProps {
    handleSubmit: (e: React.FormEvent) => Promise<void>;
    urlInput: string;
    setUrlInput: (val: string) => void;
    setShowCreate: (val: boolean) => void;
}

export const CreateModel = ({handleSubmit, urlInput, setUrlInput, setShowCreate}:CreateModelProps) =>{
    return (<div
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
        }}
    >
        <div
            style={{
                backgroundColor: "#fff",
                padding: "20px",
                borderRadius: "8px",
                width: "300px",
            }}
        >
            <h2>Створити новий URL</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    value={urlInput}
                    onChange={(e) => setUrlInput(e.target.value)}
                    placeholder="Введіть URL"
                    style={{ width: "95%", padding: "8px", marginBottom: "10px", marginRight: "20px" }}
                />
                <div style={{ display: "flex", justifyContent: "space-between" }}>
                    <button type="submit" style={{
                        padding: "8px 16px",
                        backgroundColor: "#007bff",
                        color: "#fff",
                        border: "none",
                        borderRadius: "4px",
                        cursor: "pointer",
                    }}>
                        Створити
                    </button>
                    <button
                        type="button"
                        onClick={() => {
                            setUrlInput("")
                            setShowCreate(false)}}
                        style={{
                            padding: "8px 16px",
                            backgroundColor: "#6382af",
                            color: "#fff",
                            border: "none",
                            borderRadius: "4px",
                            cursor: "pointer",
                        }}
                    >
                        Відмінити
                    </button>
                </div>
            </form>
        </div>
    </div>)
}