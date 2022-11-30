import { get, post, put, del } from './api.js';

export async function getAllPosts() {
    return await get('/data/posts?sortBy=_createdOn%20desc');
}

export async function createPost(data) {
    return await post('/data/posts', data);
}

export async function getPostById(id) {
    return await get(`/data/posts/${id}`);
}

export async function deletePost(id) {
    return await del(`/data/posts/${id}`);
}

export async function editPostById(id, data) {
    return await put(`/data/posts/${id}`, data);
}

export async function getPostsByUserId(userId) {
    return await get(`/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function makeADonation(postId) {
    return await post(`/data/applications`, { postId });
}

export async function totalDonationCount(postId) {
    return await get(`/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`);
}

export async function getSpecificUserDonation(postId, userId) {
    return await get(`/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}
