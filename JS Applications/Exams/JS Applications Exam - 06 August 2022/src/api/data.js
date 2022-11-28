import { get, post, put, del } from './api.js';

export async function getAllJobOffers() {
    return await get('/data/offers?sortBy=_createdOn%20desc');
}

export async function createJobOffer(data) {
    return await post('/data/offers', data);
}

export async function getJobOfferById(id) {
    return await get(`/data/offers/${id}`);
}

export async function editJobOfferById(id, data) {
    return await put(`/data/offers/${id}`, data);
}

export async function deleteJobOfferById(id) {
    return await del(`/data/offers/${id}`);
}

export async function apply(offerId) {
    return await post(`/data/applications`, { offerId });
}

export async function getTotalApplicationsCount(id) {
    return await get(`/data/applications?where=offerId%3D%22${id}%22&distinct=_ownerId&count`);
}

export async function getSpecificUserApplies(userId, offerId) {
    return await get(`/data/applications?where=offerId%3D%22${offerId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}


