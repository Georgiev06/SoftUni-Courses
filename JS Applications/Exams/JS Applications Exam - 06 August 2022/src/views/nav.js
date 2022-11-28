import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('nav');

const navTemplate = (hasUser) => html`
    <div>
        <a href="/dashboard">Dashboard</a>
    </div>

    ${hasUser 
        ? html`<div class="user">
        <a href="/create">Create Offer</a>
        <a href="/logout">Logout</a>
    </div>` 
        : html`<div class="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
        </div>`
    }`;

export function updateNav() {
    const user = getUserData();
    render(navTemplate(user), nav);
}