function footerPosition(element, scrollHeight, innerHeight) {

    try {
        const _element = document.querySelector('footer')
        const isTallerThanScreen = scrollHeight >= innerHeight

        _element.classList.toggle('position-fixed', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
  
} 

function toggleMenu(attribute) {

    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }


}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)
toggleMenu('[data-option="toggle"]')


















