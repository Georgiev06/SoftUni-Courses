import { html, render } from '../node_modules/lit-html/lit-html.js';

let url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const root = document.getElementById('menu');

export async function getRequest(){
    let response = await fetch(url);
    let result = await response.json();

    return [...Object.values(result)];
}

export async function postRequest(data){
    return await fetch(url, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });
}

async function fillDropdown() {
    let result = await getRequest();

    let template = html`
    ${result.map(option => html`<option .value=${option._id}>${option.text}</option>`)}
    `;
    render(template, root);
}

fillDropdown();

document.querySelector('form').addEventListener('submit', addItem);

async function addItem(e) {
    e.preventDefault();
    let text = document.querySelector('#itemText').value;
    await postRequest({ text });

    fillDropdown();
}