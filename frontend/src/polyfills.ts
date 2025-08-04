/***************************************************************************************************
 * Zone.js is required by default for Angular itself.
 */
import 'zone.js';  // Included with Angular CLI.

/***************************************************************************************************
 * APPLICATION IMPORTS
 */

(window as any).global = window;

// Polyfills para Node.js no navegador
global.Buffer = global.Buffer || require('buffer').Buffer;
global.process = global.process || require('process');

// Polyfill para setImmediate
if (typeof (window as any).setImmediate === 'undefined') {
  (window as any).setImmediate = function(fn: () => void) {
    return setTimeout(fn, 0);
  };
}

// Polyfill para clearImmediate
if (typeof (window as any).clearImmediate === 'undefined') {
  (window as any).clearImmediate = function(id: number) {
    return clearTimeout(id);
  };
}

// Suporte para globalThis
if (typeof globalThis === 'undefined') {
  (window as any).globalThis = window;
}