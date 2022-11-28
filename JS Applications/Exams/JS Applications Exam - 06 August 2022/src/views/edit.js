import { html } from "../../node_modules/lit-html/lit-html.js"
import { editJobOfferById, getJobOfferById } from "../api/data.js";

const editTemplate = (jobOffer, onSubmit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Offer</h2>
        <form class="edit-form" @submit=${onSubmit}>
            <input type="text" name="title" id="job-title" placeholder="Title" value="${jobOffer.title}" />
            <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url"
                value="${jobOffer.imageUrl}" />
            <input type="text" name="category" id="job-category" placeholder="Category" value="${jobOffer.category}" />
            <textarea id="job-description" name="description" placeholder="Description" rows="4"
                cols="50">${jobOffer.description}</textarea>
            <textarea id="job-requirements" name="requirements" placeholder="Requirements" rows="4"
                cols="50">${jobOffer.requirements}</textarea>
            <input type="text" name="salary" id="job-salary" placeholder="Salary" value="${jobOffer.salary}" />

            <button type="submit">post</button>
        </form>
    </div>
</section>
`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const jobOffer = await getJobOfferById(id);

    async function onSubmit(e) {
        e.preventDefault()
        const formData = new FormData(e.target);
        const { title, imageUrl, category, description, requirements, salary } = Object.fromEntries(formData);

        if (title == '' || imageUrl == '' || category == '' || description == '' || requirements == '' || salary == '') {
            return alert('Invalid data!')
        }

        await editJobOfferById(id, { title, imageUrl, category, description, requirements, salary });
        ctx.page.redirect(`/details/${id}`);
    }

    ctx.render(editTemplate(jobOffer, onSubmit))
}