import {html, render} from '../node_modules/lit-html/lit-html.js';

const root = document.getElementById('root');
const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);

function onSubmit(e) {
    e.preventDefault();

    let towns = [...new FormData(form).values()][0].split(', ');
    const listTemplate = html `<ul>${towns.map(town => html `<li>${town}</li>`)}</ul>`;

    render(listTemplate, root)
}