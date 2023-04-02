const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

function isValidEmail(email) {
    return emailRegex.test(email);
}

function validateRequiredFields(form) {
    let isValid = true;
    const requiredFields = form.querySelectorAll('[required]');

    requiredFields.forEach((field) => {
        if (!field.value) {
            field.classList.add('invalid');
            isValid = false;
        } else {
            field.classList.remove('invalid');
        }

        if (field.type === 'email' && !isValidEmail(field.value)) {
            field.classList.add('invalid');
            isValid = false;
        }
    });

    return isValid;
}

function initializeContactForm() {
    const form = document.querySelector('.contact-form form');
    const submitButton = form.querySelector('button[type="submit"]');

    form.addEventListener('submit', (event) => {
        const isValid = validateRequiredFields(form);

        if (!isValid) {
            event.preventDefault();
        } else {
            submitButton.disabled = true;
            submitButton.innerHTML = 'Sending...';

            // Send form data using AJAX, fetch, or other method here
            // After the request is complete, re-enable the submit button
        }
    });
}

document.addEventListener('DOMContentLoaded', () => {
    initializeContactForm();
});
