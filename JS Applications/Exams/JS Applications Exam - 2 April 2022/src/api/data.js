import { get, post, put, del } from './api.js';

export async function getAllAnimals() {
    return await get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}

export async function createAnimalCard(data) {
    return await post('/data/pets', data);
}

export async function getAnimalById(id) {
    return await get(`/data/pets/${id}`);
}

export async function deleteAnimalById(id) {
    return await del(`/data/pets/${id}`);
}

export async function editAnimalById(id, data) {
    return await put(`/data/pets/${id}`, data);
}

export async function addDonation(petId) {
    return await post(`/data/donation`, { petId });
}

export async function getTotalDonationCount(petId) {
    return await get(`/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);
}

export async function getSpecificUserDonation(petId, userId) {
    return await get(`/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}