import {UrlType, User} from "../../types";
import { UrlComponent } from "./UrlComponent";

interface UrlListProps {
    urls: UrlType[];
    fetchData: () => void;
    onDelete: (id: number) => void;
    user: User | null;

}

export const UrlList = ({urls, fetchData, onDelete, user}: UrlListProps) => {

    return (
        <div>
            {urls.map((url) => (
                <UrlComponent key={url.id} url={url} onDelete = {() => onDelete(url.id)} user ={user} />
            ))}
        </div>
    );
};
