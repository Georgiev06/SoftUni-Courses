import * as api from './api.js'

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getShoes() {
    return await api.get('http://localhost:3030/data/shoes?sortBy=_createdOn%20desc');
}

export async function getShoesById(id) {
    return await api.get(`http://localhost:3030/data/shoes/${id}`);
}

export async function createShoeCard(data) {
    return await api.post(`http://localhost:3030/data/shoes`, data);
}

export async function editShoe(id, data) {
    return await api.put(`http://localhost:3030/data/shoes/${id}`, data);
}

export async function deleteShoe(id) {
    return await api.del(`http://localhost:3030/data/shoes/${id}`);
}

export async function searchShoe(query) {
    return await api.get(`http://localhost:3030/data/shoes?where=brand%20LIKE%20%22${query}%22`);
}