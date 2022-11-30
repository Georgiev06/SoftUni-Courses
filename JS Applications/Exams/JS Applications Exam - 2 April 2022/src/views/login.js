import { html } from "../../node_modules/lit-html/lit-html.js"
import { login } from "../api/user.js";

const loginTemplate = (onSubmit) => html`
<section id="loginPage">
    <form class="loginForm" @submit=${onSubmit}>
        <img src="./images/logo.png" alt="logo" />
        <h2>Login</h2>

        <div>
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div>
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Login</button>

        <p class="field">
            <span>If you don't have profile click <a href="/register">here</a></span>
        </p>
    </form>
</section>
`;

export function loginPage(ctx) {
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault()
        const formData = new FormData(e.target);
        const { email, password } = Object.fromEntries(formData);

        if (email == '' || password == '') {
            return alert('All fields are required!')
        }

        await login(email, password);
        ctx.page.redirect('/dashboard');
        ctx.updateNav();
    }
}