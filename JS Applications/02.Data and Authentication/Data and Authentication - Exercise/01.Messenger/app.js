function attachEvents() {
    console.log('TODO...');

    const baseUrl = 'http://localhost:3030/jsonstore/messenger';

    document.getElementById('submit').addEventListener('click', postRequest)
    document.getElementById('refresh').addEventListener('click', getRequest)

    let messages = document.getElementById('messages');

    async function postRequest() {
        let authorName = document.querySelector('[name="author"]').value;
        let msgText = document.querySelector('[name="content"]').value;

        const requestData = {
            author: authorName,
            content: msgText,
        }

        const response = await fetch(baseUrl, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestData)
        });

        const data = await response.json();

        //return data;
    }

    async function getRequest() {
        const response = await fetch(baseUrl);
        const data = await response.json();

        let result = [];
        Object.values(data).forEach(message => {
            result.push(`${message.author}: ${message.content}`);
        });

        messages.value = result.join('\n');
    }
}

attachEvents();