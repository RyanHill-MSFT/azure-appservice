# Build the dependencies
FROM node:14-alpine
ENV NODE_ENV=production
ENV PROJECT_DIR=/usr/src/app

WORKDIR ${PROJECT_DIR}

COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]
ENV PATH ${PROJECT_DIR}/node_modules/.bin:$PATH
RUN npm install

# Copy the app
COPY . .

# Run the app
EXPOSE 3000 2222
CMD ["npm", "start"]