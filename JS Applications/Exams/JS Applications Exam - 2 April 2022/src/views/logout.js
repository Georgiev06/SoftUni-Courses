import { logout } from "../api/user.js";

export async function logoutPage(ctx) {
    await logout();
    ctx.page.redirect('/dashboard');
    ctx.updateNav();
}