const PROXY_CONFIG = [
  {
    context: [
      "/products",
    ],
    target: "https://localhost:7026",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
