import { html } from "../../node_modules/lit-html/lit-html.js"
import { editPostById, getPostById } from "../api/data.js";

const editTemplate = (post, onSubmit) => html`<section id="edit-page" class="auth">
    <form id="edit" @submit=${onSubmit}>
        <h1 class="title">Edit Post</h1>

        <article class="input-group">
            <label for="title">Post Title</label>
            <input type="title" name="title" id="title" value="${post.title}">
        </article>

        <article class="input-group">
            <label for="description">Description of the needs </label>
            <input type="text" name="description" id="description" value="${post.description}">
        </article>

        <article class="input-group">
            <label for="imageUrl"> Needed materials image </label>
            <input type="text" name="imageUrl" id="imageUrl" value="${post.imageUrl}">
        </article>

        <article class="input-group">
            <label for="address">Address of the orphanage</label>
            <input type="text" name="address" id="address" value="${post.address}">
        </article>

        <article class="input-group">
            <label for="phone">Phone number of orphanage employee</label>
            <input type="text" name="phone" id="phone" value="${post.phone}">
        </article>

        <input type="submit" class="btn submit" value="Edit Post">
    </form>
</section>`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const post = await getPostById(id);

    ctx.render(editTemplate(post, onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target)
        const { title, description, imageUrl, address, phone } = Object.fromEntries(formData);

        if (title == '' || description == '' || imageUrl == '' || address == '' || phone == '') {
            return alert('Invalid data!')
        }

        await editPostById(id, { title, description, imageUrl, address, phone });
        ctx.page.redirect(`/details/${id}`)
    }
}