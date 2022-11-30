import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { deleteAnimalById, addDonation, getAnimalById, getTotalDonationCount, getSpecificUserDonation } from "../api/data.js";

const detailsTemplate = (animal, isOwner, isRegistered, donationsCount, canDonate, onDelete, onDonate) => html`<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${animal.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${animal.name}</h1>
                <h3>Breed: ${animal.breed}</h3>
                <h4>Age: ${animal.age}</h4>
                <h4>Weight: ${animal.weight}</h4>
                <h4 class="donation">Donation: ${donationsCount * 100}$</h4>
            </div>
            ${isRegistered ? html`
            <div class="actionBtn">

                ${isOwner 
                ? html`
                <a href="/edit/${animal._id}" class="edit">Edit</a>
                <a href="javascript:void(0)" @click=${onDelete} class="remove">Delete</a>` 
                : nothing}

                ${canDonate 
                ? html`<a href="javascript:void(0)" @click=${onDonate} class="donate">Donate</a>` 
                : nothing }

            </div>`: nothing}
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;

    const animal = await getAnimalById(id)
    const donationsCount = await getTotalDonationCount(animal._id);
    const isDonated = await getSpecificUserDonation(animal._id, ctx.user._id);

    const isRegistered = ctx.user?._id;
    const isOwner = ctx.user._id == animal._ownerId;
    const canDonate = !isOwner && !isDonated


    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this pet card?')

        if (confirmed) {
            await deleteAnimalById(id);
            ctx.page.redirect('/dashboard');
        }
    }

    async function onDonate() {
        await addDonation(id);
        ctx.page.redirect(`/details/${id}`);
    }

    ctx.render(detailsTemplate(animal, isOwner, isRegistered, donationsCount, canDonate, onDelete, onDonate));
}