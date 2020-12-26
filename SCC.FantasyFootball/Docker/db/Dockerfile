FROM postgres:latest AS build-env
WORKDIR /app

ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD postgres
ENV POSTGRES_DB postgres

# Expose the PostgreSQL port
EXPOSE 5432

# Add VOLUMEs to allow backup of config, logs and databases
VOLUME  ["/etc/postgresql", "/var/log/postgresql", "/var/lib/postgresql"]

# Set the default command to run when starting the container
CMD ["postgres"]