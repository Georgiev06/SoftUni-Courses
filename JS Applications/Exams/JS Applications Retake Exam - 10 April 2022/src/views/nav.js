import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getUserData } from "../util.js";

const header = document.querySelector('header');

const navTemplate = (hasUser) => html`
<h1><a href="/">Orphelp</a></h1>
<nav>
    <a href="/dashboard">Dashboard</a>
    
    ${hasUser 
    ? html`<div id="user">
        <a href="/myPosts">My Posts</a>
        <a href="/create">Create Post</a>
        <a href="/logout">Logout</a>
    </div>`
    : html`<div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`}
</nav>`;

export function updateNav() {
    const user = getUserData();
    render(navTemplate(user), header);
}