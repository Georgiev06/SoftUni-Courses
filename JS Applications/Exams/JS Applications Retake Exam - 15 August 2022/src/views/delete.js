import { deleteShoe } from "../api/data.js"
import { updateNav } from "../app.js";

export async function deletePage(ctx) {
    const id = ctx.params.id;

    const confirmed = confirm('Are you sure you want to delete this shoe?');

    if (confirmed) {
        await deleteShoe(id);
        ctx.page.redirect('/dashboard');
        updateNav();
    }
}