import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../api/data.js";
import { updateNav } from "../app.js";


const loginTemplate = (onSubmit) => html`
<section id="login">
    <div class="form">
        <h2>Login</h2>
        <form class="login-form" @submit=${onSubmit}>
            <input type="text" name="email" id="email" placeholder="email" />
            <input type="password" name="password" id="password" placeholder="password" />
            <button type="submit">login</button>
            <p class="message">
                Not registered? <a href="/register">Create an account</a>
            </p>
        </form>
    </div>
</section>
`;

export function loginPage(ctx) {
    async function onSubmit(e) {
        e.preventDefault();
        const formData = new FormData(e.target);
        const { email, password } = Object.fromEntries(formData);

        if (email == '' || password == '') {
            return alert('Invalid data!');
        }

        await login(email, password);
        ctx.page.redirect('/')
        updateNav();
    }

    ctx.render(loginTemplate(onSubmit));
}