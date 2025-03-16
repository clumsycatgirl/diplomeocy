/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    '../DiplomeocyWeb/Views/**/*.cshtml',
    '../RazorComponents/**/*.razor',
    './node_modules/preline/dist/*.js',
  ],
  
  theme: {
    extend: {
      colors: {
        primary: {
          100: '#e3e7ee',
          200: '#c2ccdb',
          300: '#a1b1c7',
          400: '#8096b3',
          500: '#123457',
          600: '#0f2d4b',
          700: '#0c263f',
          800: '#091f33',
          900: '#061728',
        },
        secondary: {
        },
      },
      fontFamily: {
        lobster: ['Lobster', 'cursive'],
      }
    },
  },
  
  plugins: [
    require('@tailwindcss/forms'),
    require('preline/plugin'),
  ],
  
  darkMode: 'class',
}

