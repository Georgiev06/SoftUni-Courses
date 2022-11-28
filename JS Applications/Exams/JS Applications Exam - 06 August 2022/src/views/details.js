import { html, nothing } from "../../node_modules/lit-html/lit-html.js"
import { apply, getJobOfferById, getSpecificUserApplies, getTotalApplicationsCount, deleteJobOfferById } from "../api/data.js";

const detailsTemplate = (isOwner, jobOffer, count, canApply, onApply, onDelete) => html`
<section id="details">
    <div id="details-wrapper">
        <img id="details-img" src="${jobOffer.imageUrl}" alt="example1" />
        <p id="details-title">${jobOffer.title}</p>
        <p id="details-category">
            Category: <span id="categories">${jobOffer.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${jobOffer.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
                <h4>Description</h4>
                <span>${jobOffer.description}</span>
            </div>
            <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${jobOffer.requirements}</span>
            </div>
        </div>
        <p>Applications: <strong id="applications">${count}</strong></p>

        <div id="action-buttons">
        ${isOwner 
            ? html`
            <a href= "/edit/${jobOffer._id}" id="edit-btn">Edit</a>
            <a href= "javascript:void(0)" @click=${onDelete} id="delete-btn">Delete</a>`
            : nothing
        }
        ${canApply 
            ? html`<a href="javascript:void(0)" @click=${onApply} id="apply-btn">Apply</a>` 
            : nothing}
        </div>
</section>
`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const jobOffer = await getJobOfferById(id);
    const applicationsCount = await getTotalApplicationsCount(id);
    const isApplied = await getSpecificUserApplies(ctx.user?._id, id);
    const isOwner = ctx.user?._id == jobOffer._ownerId;
    const canApply = !isOwner && Boolean(ctx.user) && !isApplied

    ctx.render(detailsTemplate(isOwner, jobOffer, applicationsCount, canApply, onApply, onDelete));
    async function onApply() {
        await apply(jobOffer._id);
        ctx.page.redirect(`/details/${id}`);
    }

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this job offer?')
        const id = ctx.params.id;

        if (confirmed) {
            await deleteJobOfferById(id)
            ctx.page.redirect('/dashboard');
        }
    }
}
