const sidebar = document.getElementById('tables-sidebar');
let startX;
let isSwiping = false;
document.body.addEventListener('touchstart', function (e) {
    startX = e.touches[0].clientX;
    isSwiping = true;
});
document.body.addEventListener('touchmove', function (e) {
    if (isSwiping) {
        console.log('swiping');
        let currentX = e.touches[0].clientX;
        let distance = currentX - startX;
        if (distance > 50) {
            sidebar.classList.remove('-translate-x-full');
            sidebar.classList.add('hs-overlay-open:translate-x-0');
        }
    }
});
document.body.addEventListener('touchend', function (e) {
    isSwiping = false;
});
document.addEventListener('click', function (e) {
    const sidebarElement = sidebar;
    const target = e.target;
    if (!sidebarElement.contains(target)) {
        sidebarElement.classList.add('-translate-x-full');
        sidebarElement.classList.remove('hs-overlay-open:translate-x-0');
    }
});
