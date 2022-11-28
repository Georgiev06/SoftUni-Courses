import * as api from '../api/api.js'
import { updateNav } from '../app.js';

export async function logoutPage(ctx) {
    await api.logout();
    ctx.page.redirect('/');
    updateNav(); 
}