import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import {HomePage} from "../pages/Home";
import Login from "../pages/Login";
import { useContext } from "react";
import { AuthContext } from "../contexts/AuthContext";

const AppRouter = () => {
    const auth = useContext(AuthContext);
    if (!auth) throw new Error("AuthContext not found");

    const { user } = auth;

    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={!user ? <Login /> : <Navigate to="/" />} />
    <Route path="/" element={ <HomePage />} />
    </Routes>
    </BrowserRouter>
);
};

export default AppRouter;
