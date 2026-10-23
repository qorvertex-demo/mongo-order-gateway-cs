> **Part of the [QorVertex live demo](https://qorvertex.com).** A small sample application that shows one MongoDB collection (`orders`) shared by five services in four languages. It is intentionally minimal and not production code.

# mongo-order-gateway-cs
C# (MongoDB.Driver) gateway. Reads/updates the shared `orders` collection and
writes `shipments`. Fixture for DB9 cross-language MongoDB coupling.
