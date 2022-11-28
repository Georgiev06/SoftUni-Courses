async function request(url, options) {
    try {
        const response = await fetch(url, options);

        if (response.ok == false) {
            const err = await response.json();
            console.log(err);
            throw new Error(err.message)
        }

        try {
            const data = await response.json();
            return data;
        } catch (error) {
            console.log(error);
            return response;       
        }
    } catch (error) {
        alert(error.message);
        throw error
    }
}

function getOptions(method, body) {
    const options = {
        method,
        headers: {}
    };

    const token = sessionStorage.getItem('authToken');
    
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json'
        options.body = JSON.stringify(body);
    }

    return options;
}


export async function get(url) {
    return await request(url, getOptions('GET'));
}

export async function post(url, data) {
    return await request(url, getOptions('POST', data));
}

export async function put(url, data) {
    return await request(url, getOptions('PUT', data));
}

export async function del(url) {
    return await request(url, getOptions('DELETE'));
}

export async function login(email, password) {
    const result = await post(`http://localhost:3030/users/login`, {email, password});

    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('email', email);

    return result;
}

export async function register(email, password) {
    const result = await post(`http://localhost:3030/users/register`, {email, password});

    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('email', email);

    return result;
}

export async function logout() {
    const result = await get(`http://localhost:3030/users/logout`);

    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('email');

    return result;
}

