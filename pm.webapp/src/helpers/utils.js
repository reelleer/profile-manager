const formatDate = (value) =>
  value ? new Date(Date.parse(value)).toISOString().slice(0, 10) : "";

export { formatDate };
