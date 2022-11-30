import { getUserData } from '../util.js';

const host = `http://localhost:3030`;

async function requester(method, url, data) {
    const options = {
        method,
        headers: {}
    }

    if (data !== undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data)
    }

    const user = getUserData();

    if (user) {
        options.headers['X-Authorization'] = user.accessToken
    }

    try {
        const response = await fetch(host + url, options);

        if (response.status == 204) {
            return response;
        }

        const result = await response.json();

        if (response.ok == false) {
            throw new Error(result.message);
        }

        return result;

    } catch (err) {
        alert(err.message);
        throw err;
    }
}

export const get = requester.bind(null, 'GET');
export const post = requester.bind(null, 'POST');
export const put = requester.bind(null, 'PUT');
export const del = requester.bind(null, 'DELETE');