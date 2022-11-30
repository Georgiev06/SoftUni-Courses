import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { deletePost, makeADonation, getPostById, getSpecificUserDonation, totalDonationCount } from "../api/data.js";

const detailsTemplate = (post, isOwner, canDonate, donationsCount, onDelete, onDonate) => html`<section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img src="${post.imageUrl}" alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${post.title}</h2>
                <p class="post-description">Description: ${post.description}</p>
                <p class="post-address">Address: ${post.address}</p>
                <p class="post-number">Phone number: ${post.phone}</p>
                <p class="donate-Item">Donate Materials: ${donationsCount}</p>

                <div class="btns">
                    ${isOwner 
                    ? html`
                        <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
                        <a href="javascript:void(0)" @click=${onDelete} class="delete-btn btn">Delete</a>` 
                    : nothing
                    }

                    ${canDonate 
                        ? html `<a href="javascript:void(0)" @click=${onDonate} class="donate-btn btn">Donate</a>` 
                        : nothing
                    }
                </div>
            </div>
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    
    const post = await getPostById(id);
    const donationsCount = await totalDonationCount(id);
    const isDonated = await getSpecificUserDonation(id, ctx.user._id);

    let isOwner = post._ownerId == ctx.user._id;
    let canDonate = !isOwner && Boolean(ctx.user) && !isDonated;
    
    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this post?')
        
        if (confirmed) {
            await deletePost(id);
            ctx.page.redirect('/dashboard')
        }
    }
    
    async function onDonate() {
        await makeADonation(id);
        ctx.page.redirect(`/details/${id}`)
    }

    ctx.render(detailsTemplate(post, isOwner, canDonate, donationsCount, onDelete, onDonate));
}