# Linux
#PCSC_CFLAGS := $(shell pkg-config --cflags libpcsclite)
#LDFLAGS := $(shell pkg-config --libs libpcsclite)
DEFAULT_PCSC_FLAGS = -Iextapi
DEFAULT_PCSC_LIB = -lpcsclite

# Mac OS X
#PCSC_CFLAGS := -framework PCSC

CFLAGS += $(PCSC_CFLAGS)

test: test.c
