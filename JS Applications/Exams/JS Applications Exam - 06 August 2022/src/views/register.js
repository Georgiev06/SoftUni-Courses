import { html } from "../../node_modules/lit-html/lit-html.js"
import { register } from "../api/user.js";

const registerTemplate = (onSubmit) => html`
<section id="register">
    <div class="form">
        <h2>Register</h2>
        <form class="login-form" @submit=${onSubmit}>
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
    </div>
</section>
`;

export function registerPage(ctx) {
    ctx.render(registerTemplate(onSubmit))

    async function onSubmit(e) {
        e.preventDefault()
        const formData = new FormData(e.target);
        const { email, password, ['re-password']: rePass } = Object.fromEntries(formData);

        if (email == '' || password == '' || rePass == '') {
            return alert('All fields are required!');
        }

        if (password != rePass) {
            return alert('Passwords don\'t match!')
        }

        await register(email, password, rePass);
        ctx.page.redirect('/dashboard');
        ctx.updateNav();
    }
}