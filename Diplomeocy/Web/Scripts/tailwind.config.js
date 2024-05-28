/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    '../Views/**/*.cshtml',
    '../Components/**/*.razor',
    './node_modules/preline/dist/*.js',
  ],
  
  theme: {
    extend: {},
    fontFamily: {
      lobster: ['Lobster', 'cursive'],
    }
  },
  
  plugins: [
    require('@tailwindcss/forms'),
    require('preline/plugin'),
  ],
  
  darkMode: 'class',
}

