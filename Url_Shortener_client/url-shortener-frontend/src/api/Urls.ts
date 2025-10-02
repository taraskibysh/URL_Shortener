import { UrlType } from "../types";
import {apiClient} from "./Client";


export const GetAll = async (): Promise<UrlType[]> => {
    const response = await apiClient.get<UrlType[]>("/Url");
    return response.data;
};

export const CreateUrl = async (url: string): Promise<UrlType> => {
    const response = await apiClient.post<UrlType>("/Url", {Url: url });
    return response.data;
};

export const UpdateUrl = async (url: string, regenerateUrl : boolean, id:number): Promise<UrlType> => {
        const response = await apiClient.put<UrlType>(`/Url/${id}`, {url:url, changeUrl:regenerateUrl});
        return response.data;

};

export const DeleteUrl = async (id : number): Promise<number> => {
        const response = await apiClient.delete<number>(`/Url/${id}`);
        return response.data;

};



