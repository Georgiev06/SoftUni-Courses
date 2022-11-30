import { html } from "../../node_modules/lit-html/lit-html.js"
import { getPostsByUserId } from "../api/data.js";

const myPostsTemplate = (posts) => html`<section id="my-posts-page">
    <h1 class="title">My Posts</h1>

    <div class="my-posts">
        ${posts.length === 0 ? html`<h1 class="title no-posts-title">You have no posts yet!</h1>` : posts.map(post =>
        myPostTemplate(post))}
    </div>

</section>`;

const myPostTemplate = (post) => html`<div class="post">
    <h2 class="post-title">${post.title}</h2>
    <img class="post-image" src="${post.imageUrl}" alt="Material Image">
    <div class="btn-wrapper">
        <a href="/details/${post._id}" class="details-btn btn">Details</a>
    </div>
</div>`;

export async function myPostsPage(ctx) {
    const userId = ctx.user._id;
    const posts = await getPostsByUserId(userId);
    ctx.render(myPostsTemplate(posts));
}