FROM node:14-alpine
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]
RUN npm install
COPY . .
RUN mkdir -p /tmp
COPY ssh_setup.sh /tmp
COPY sshd_config /etc/ssh/
RUN apk add openssh \
     && echo "root:Docker!" | chpasswd \
     && chmod +x /usr/src/app/entrypoint.sh \
     && chmod +x /tmp/ssh_setup.sh \
     && (sleep 1;/tmp/ssh_setup.sh 2>&1 > /dev/null) \
     && chmod a+w /etc/ssh/sshd_config 
EXPOSE 3000 2222
ENTRYPOINT [ "/usr/src/app/entrypoint.sh" ]
CMD [ "npm", "start" ]
