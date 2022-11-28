import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from '../api/data.js';
import { updateNav } from "../app.js";

const registerTemplate = (onSubmit) => html`
<section id="register">
    <div class="form">
        <h2>Register</h2>
        <form class="login-form" @submit=${onSubmit}>
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">login</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
    </div>
</section>`;

export function registerPage(ctx) {
    async function onSubmit(e) {
        e.preventDefault();
        const formData = new FormData(e.target);
        const { email, password } = Object.fromEntries(formData);
        const rePass = formData.get('re-password');

        if (email == '' || password == '' || rePass == '') {
            return alert('Invalid data!');
        }

        if (password != rePass) {
            return alert('Passwords don\'t match!');
        }

        await register(email, password);
        ctx.page.redirect('/')
        updateNav();
    }

    ctx.render(registerTemplate(onSubmit));
}