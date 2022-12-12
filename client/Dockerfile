FROM node:latest as build-stage

WORKDIR /app
COPY package*.json /app/
RUN npm install
COPY . .
RUN npm run build

FROM nginx
RUN rm -rf /usr/share/nginx/html/*

COPY nginx.conf /etc/nginx/conf.default
COPY --from=build-stage /app/build /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]


FROM node:16.15.0 as node
WORKDIR /app
COPY . .
RUN npm install --force
RUN npm run build --prod


FROM nginx:alpine
COPY --from=node /app/dist /usr/share/nginx/html