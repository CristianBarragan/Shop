export class InMemoryProductService {
  createDb() {
    let products = [
      { id: 1, name: 'Prod1' },
      { id: 2, name: 'Prod2' },
      { id: 3, name: 'Prod3' },
      { id: 4, name: 'Prod4' },
      { id: 5, name: 'Prod5' },
      { id: 6, name: 'Prod6' },
      { id: 7, name: 'Prod7' },
      { id: 8, name: 'Prod8' },
      { id: 9, name: 'Prod9' },
      { id: 10, name: 'Prod10' }
    ];
    return { products };
  }
}