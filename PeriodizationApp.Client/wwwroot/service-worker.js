self.addEventListener('install', event => {
    console.log('El motor de Odysseus se ha instalado correctamente.');
    self.skipWaiting();
});

self.addEventListener('fetch', event => {
    // Este interceptor es el requisito mínimo de los navegadores 
    // para habilitarnos el botón de "Instalar App".
});