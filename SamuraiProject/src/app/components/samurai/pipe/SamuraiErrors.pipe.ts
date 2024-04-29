import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'samuraiErrors', // Set the pipe name to 'samuraiErrors'
  standalone: true, // Mark it as a standalone pipe
})
export class SamuraiErrorsPipe implements PipeTransform {
  transform(errors: any): string | null {
    if (!errors) {
      return null; // No errors
    }

    const errorMessages = []; // Array to store error messages

    // Loop through error keys
    for (const key of Object.keys(errors)) {
      // Access corresponding message based on key
      const message = this.getErrorMessage(key, errors[key]);
      if (message) {
        errorMessages.push(message); // Add message if valid
      }
    }

    return errorMessages.join(', '); // Join messages with comma separator
  }

  private getErrorMessage(key: string, value: any): string | null {
    switch (key) {
      case 'required':
        return 'This field is required.';
      case 'minLength':
        if (typeof value === 'boolean') { // Check if value is a boolean
          return `Minimum length is required.`; // Default message
        } else if (value && value.requiredLength) { // Check for object structure
          return `Minimum length is ${value.requiredLength}.`;
        }
        return null; // Handle unknown minLength value format
      case 'pattern': // Add cases for other validation keys as needed
        return 'Invalid format.';
      default:
        return null; // Unknown error key
    }
  }
}
