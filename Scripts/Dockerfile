FROM node:20 AS build
WORKDIR /app

COPY Scripts/package.json Scripts/package-lock.json ./
RUN npm install

COPY Scripts ./
RUN npm run build

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build /app/dist ./
COPY nginx/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
