### 3 Steps for Modeling a Complex Domain
1. Identify Entities and treat each entity as an aggregate root
2. Identify relationships between the entities
3. Merge aggregates if there are constraints

### Possible constraints:
1. Enforcing Invariants
2. Eventual consistency cannot be tolerated

### Good indicators that an entity should be an aggregate root:
1. It is referenced by other aggregates
2. It will be looked up by Id