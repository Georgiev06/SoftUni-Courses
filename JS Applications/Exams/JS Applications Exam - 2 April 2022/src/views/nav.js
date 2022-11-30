import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('nav');

const navTemplate = (hasUser) => html`
<section class="logo">
    <img src="./images/logo.png" alt="logo">
</section>
    <ul>
        <li><a href="/">Home</a></li>
        <li><a href="/dashboard">Dashboard</a></li>
        ${hasUser 
            ? html`<li><a href="create">Create Postcard</a></li>
                   <li><a href="/logout">Logout</a></li>` 
            : html`<li><a href="/login">Login</a></li>
                   <li><a href="register">Register</a></li>` }
        
    </ul>
`;

export function updateNav() {
    const user = getUserData();
    render(navTemplate(user), nav);
}