# Stage 1: Compile and Build Angular
FROM node:latest as build
WORKDIR /usr/local/app
COPY ./ /usr/local/app/
RUN npm install
RUN npm run build-dev

# Stage 2: Serve app with nginx server
FROM nginx:latest
COPY --from=build /usr/local/app/dist/electricity-consumption.web /usr/share/nginx/html
EXPOSE 80